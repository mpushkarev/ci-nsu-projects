import { PointsList } from './components/PointsList';
import { Tabs, TabsList, TabsTrigger, TabsContent } from './components/ui/tabs';
import type { Point } from './types/point';
import { MapContainer, TileLayer, useMap } from 'react-leaflet';

// Пример данных для демонстрации
const samplePoints: Point[] = [
  {
    id: '1',
    address: 'г. Новосибирск, ул. Ленина, д. 1',
    description: 'Свалка старых шин возле жилого дома.',
    date: '2024-06-15T10:37:00',
    status: 'pending' as const,
  },
  {
    id: '2',
    address: 'г. Новосибирск, пр. Дзержинского, д. 45',
    description: 'Груда покрышек на обочине дороги.',
    date: '2024-06-20T14:29:00',
    status: 'queued' as const,
  },
  {
    id: '3',
    address: 'г. Новосибирск, ул. Советская, д. 10',
    description:
      'Старые шины, оставленные рядом с детской площадкой. Это создает опасность для детей и ухудшает внешний вид района.',
    date: '2024-06-25T16:21:00',
    status: 'in_progress' as const,
  },
  {
    id: '4',
    address: 'г. Новосибирск, ул. Красный проспект, д. 100',
    description: 'Незаконная свалка шин на пустыре.',
    date: '2024-07-01T09:13:00',
    status: 'completed' as const,
  },
  {
    id: '5',
    address: 'г. Новосибирск, ул. Пушкина, д. 50',
    description: 'Старые покрышки, оставленные у гаражей.',
    date: '2024-07-10T11:45:00',
    status: 'deleted' as const,
  },
];

function App() {
  return (
    <div className="bg-gray-50 relative">
      <Tabs defaultValue="map" className="w-full h-dvh">
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
          <div className="w-full h-dvh bg-green-500 flex items-center justify-center">
            <div className="text-center text-white">
              <div className="text-6xl mb-4">🗺️</div>
              <h3 className="text-3xl font-bold mb-2">Интерактивная карта</h3>
              <p className="text-green-100 text-lg">
                Здесь будет отображаться карта с точками
              </p>
            </div>
          </div>
        </TabsContent>

        {/* Контент списка - начинается под табами */}
        <TabsContent value="list" className="mt-0 h-dvh overflow-y-auto">
          <div className="container mx-auto px-4 pt-20 pb-5">
            <PointsList
              points={samplePoints}
              defaultFilter="all"
              isAdmin={true}
            />
          </div>
        </TabsContent>
      </Tabs>
    </div>
  );
}

export default App;
