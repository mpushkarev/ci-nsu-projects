import { PointsList } from './components/PointsList';
import { Button } from './components/ui/button';
import type { Point } from './types/point';
import {
  Drawer,
  DrawerClose,
  DrawerContent,
  DrawerDescription,
  DrawerFooter,
  DrawerHeader,
  DrawerTitle,
  DrawerTrigger,
} from '@/components/ui/drawer';

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
    status: 'completed' as const,
  },
];

function App() {
  return (
    <>
      <div className="min-h-svh bg-gray-100 py-8">
        <div className="container mx-auto px-4">
          <h1 className="text-3xl font-bold text-center mb-8 text-gray-800">
            Карта покрышек - Точки на карте
          </h1>
          <PointsList points={samplePoints} defaultFilter="all" />
        </div>
      </div>
    </>
  );
}

export default App;
