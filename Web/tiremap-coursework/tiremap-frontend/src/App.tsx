import { PointsList } from './components/PointsList';
import { Tabs, TabsList, TabsTrigger, TabsContent } from './components/ui/tabs';
import type { Point } from './types/point';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import {
  Routes,
  Route,
  Navigate,
  useLocation,
  useNavigate,
} from 'react-router-dom';
import 'leaflet/dist/leaflet.css';
import { Button } from '@/components/ui/button';
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from '@/components/ui/card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { getAllPoints } from './api/pointsApi';
import { useState, useEffect } from 'react';

// Пример данных для демонстрации
const samplePoints: Point[] = [
  {
    id: '1',
    address: 'г. Новосибирск, ул. Ленина, д. 1',
    description: 'Свалка старых шин возле жилого дома.',
    createdAt: '2024-06-15T10:37:00',
    status: 'pending' as const,
  },
  {
    id: '2',
    address: 'г. Новосибирск, пр. Дзержинского, д. 45',
    description: 'Груда покрышек на обочине дороги.',
    createdAt: '2024-06-20T14:29:00',
    status: 'queued' as const,
  },
  {
    id: '3',
    address: 'г. Новосибирск, ул. Советская, д. 10',
    description:
      'Старые шины, оставленные рядом с детской площадкой. Это создает опасность для детей и ухудшает внешний вид района.',
    createdAt: '2024-06-25T16:21:00',
    status: 'in_progress' as const,
  },
  {
    id: '4',
    address: 'г. Новосибирск, ул. Красный проспект, д. 100',
    description: 'Незаконная свалка шин на пустыре.',
    createdAt: '2024-07-01T09:13:00',
    status: 'completed' as const,
  },
  {
    id: '5',
    address: 'г. Новосибирск, ул. Пушкина, д. 50',
    description: 'Старые покрышки, оставленные у гаражей.',
    createdAt: '2024-07-10T11:45:00',
    status: 'deleted' as const,
  },
];

function App() {
  const location = useLocation();
  const navigate = useNavigate();

  const [points, setPoints] = useState(samplePoints); // начинаем с samplePoints

  // Загружаем данные при старте приложения
  useEffect(() => {
    const loadPoints = async () => {
      try {
        const apiPoints = await getAllPoints();
        setPoints(apiPoints); // заменяем samplePoints на данные с API
      } catch (error) {
        console.error('Не удалось загрузить точки:', error);
        // оставляем samplePoints если API недоступно
      } finally {
      }
    };

    loadPoints();
  }, []); // [] означает "выполнить один раз при загрузке"

  // Проверяем, находимся ли мы на админ-странице
  if (location.pathname === '/admin') {
    return (
      <div className="w-full h-dvh flex items-center justify-center bg-gray-50">
        <Card className="w-full max-w-sm">
          <CardHeader>
            <CardTitle>Вход в аккаунт</CardTitle>
            <CardDescription>
              Войдите, чтобы получить доступ к админке
            </CardDescription>
          </CardHeader>
          <CardContent>
            <form>
              <div className="flex flex-col gap-6">
                <div className="grid gap-2">
                  <Label htmlFor="login">Логин</Label>
                  <Input
                    id="login"
                    type="text"
                    placeholder="some-name"
                    required
                  />
                </div>
                <div className="grid gap-2">
                  <Label htmlFor="password">Пароль</Label>
                  <Input id="password" type="password" required />
                </div>
              </div>
            </form>
          </CardContent>
          <CardFooter className="flex-col gap-2">
            <Button type="submit" className="w-full">
              Войти
            </Button>
          </CardFooter>
        </Card>
      </div>
    );
  }

  // Определяем активный таб на основе URL для остальных страниц
  const activeTab = location.pathname === '/list' ? 'list' : 'map';

  // Обработчик изменения таба
  const handleTabChange = (value: string) => {
    navigate(`/${value}`, { replace: true });
  };

  return (
    <div className="bg-gray-50 relative">
      <Routes>
        <Route path="/" element={<Navigate to="/map" replace />} />
        <Route
          path="/map"
          element={
            <Tabs
              value={activeTab}
              onValueChange={handleTabChange}
              className="w-full h-dvh"
            >
              {/* Фиксированные табы сверху с мягким градиентом */}
              <div className="fixed top-0 left-0 right-0 z-50 bg-linear-to-b from-gray-50/95 via-gray-50/90 to-gray-50/75 drop-shadow-gray-50/50 drop-shadow-sm pb-4">
                <div className="flex justify-center pt-4">
                  <TabsList className="grid w-fit grid-cols-2 bg-white/75 border border-gray-200">
                    <TabsTrigger value="map" className="px-8">
                      Карта
                    </TabsTrigger>
                    <TabsTrigger value="list" className="px-8">
                      Список
                    </TabsTrigger>
                  </TabsList>
                </div>
              </div>

              {/* Контент карты - на весь экран */}
              <TabsContent value="map" className="mt-0">
                <div className="w-full h-dvh relative z-0">
                  <MapContainer
                    center={[54.8464, 83.0518]}
                    zoom={18}
                    scrollWheelZoom={true}
                    zoomControl={false}
                    className="w-full h-full z-0"
                  >
                    <TileLayer
                      attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                      url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                    />
                    <Marker position={[54.8464, 83.0518]}>
                      <Popup>ВКИ НГУ (окак)</Popup>
                    </Marker>
                  </MapContainer>
                </div>
              </TabsContent>

              {/* Контент списка - начинается под табами */}
              <TabsContent value="list" className="mt-0 h-dvh overflow-y-auto">
                <div className="container mx-auto px-4 pt-20 pb-5">
                  <PointsList
                    points={points}
                    defaultFilter="all"
                    isAdmin={false}
                  />
                </div>
              </TabsContent>
            </Tabs>
          }
        />
        <Route
          path="/list"
          element={
            <Tabs
              value={activeTab}
              onValueChange={handleTabChange}
              className="w-full h-dvh"
            >
              {/* Фиксированные табы сверху с мягким градиентом */}
              <div className="fixed top-0 left-0 right-0 z-50 bg-linear-to-b from-gray-50/95 via-gray-50/90 to-gray-50/75 drop-shadow-gray-50/50 drop-shadow-sm pb-4">
                <div className="flex justify-center pt-4">
                  <TabsList className="grid w-fit grid-cols-2 bg-white/75 border border-gray-200">
                    <TabsTrigger value="map" className="px-8">
                      Карта
                    </TabsTrigger>
                    <TabsTrigger value="list" className="px-8">
                      Список
                    </TabsTrigger>
                  </TabsList>
                </div>
              </div>

              {/* Контент карты - на весь экран */}
              <TabsContent value="map" className="mt-0">
                <div className="w-full h-dvh relative z-0">
                  <MapContainer
                    center={[54.8464, 83.0518]}
                    zoom={18}
                    scrollWheelZoom={true}
                    zoomControl={false}
                    className="w-full h-full z-0"
                  >
                    <TileLayer
                      attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                      url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                    />
                    <Marker position={[54.8464, 83.0518]}>
                      <Popup>ВКИ НГУ (окак)</Popup>
                    </Marker>
                  </MapContainer>
                </div>
              </TabsContent>

              {/* Контент списка - начинается под табами */}
              <TabsContent value="list" className="mt-0 h-dvh overflow-y-auto">
                <div className="container mx-auto px-4 pt-20 pb-5">
                  <PointsList
                    points={points}
                    defaultFilter="all"
                    isAdmin={false}
                  />
                </div>
              </TabsContent>
            </Tabs>
          }
        />
      </Routes>
    </div>
  );
}

export default App;
