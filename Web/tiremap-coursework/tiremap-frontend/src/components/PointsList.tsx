import { useState, useMemo } from 'react';
import { PointCard } from './PointCard';
import { Button } from '@/components/ui/button';
import {
  Drawer,
  DrawerClose,
  DrawerContent,
  DrawerDescription,
  DrawerFooter,
  DrawerHeader,
  DrawerTitle,
} from '@/components/ui/drawer';
import type { Point, FilterStatus } from '@/types/point';
import { Badge } from './ui/badge';
import { Textarea } from './ui/textarea';

interface PointsListProps {
  points: Point[];
  defaultFilter?: FilterStatus;
}

export function PointsList({ points, defaultFilter = 'all' }: PointsListProps) {
  const [filterStatus, setFilterStatus] = useState<FilterStatus>(defaultFilter);
  const [selectedPoint, setSelectedPoint] = useState<Point | null>(null);
  const [isDrawerOpen, setIsDrawerOpen] = useState(false);

  const filteredPoints = useMemo(() => {
    let filteredPoints = points;

    if (filterStatus !== 'all') {
      filteredPoints = points.filter((point) => point.status === filterStatus);
    }

    return filteredPoints;
  }, [points, filterStatus]);

  const handlePointClick = (point: Point) => {
    setSelectedPoint(point);
    setIsDrawerOpen(true);
  };

  const handleDrawerClose = () => {
    setIsDrawerOpen(false);
    setSelectedPoint(null);
  };

  const statusLabels = {
    all: 'Все',
    pending: 'На рассмотрении',
    queued: 'В очереди',
    in_progress: 'В работе',
    completed: 'Выполнено',
    deleted: 'Удалено',
  };

  return (
    <div className="w-full space-y-4">
      {/* Панель управления */}
      <div className="flex flex-col w-full max-w-3xl ml-auto mr-auto gap-4 p-4 bg-gray-50 rounded-lg">
        <div className="flex flex-col space-y-2">
          <span className="text-sm font-medium text-gray-700">
            Фильтр по статусу:
          </span>
          <div className="flex gap-2 flex-wrap">
            {(Object.keys(statusLabels) as FilterStatus[]).map((status) => (
              <Button
                key={status}
                variant={filterStatus === status ? 'default' : 'outline'}
                size="sm"
                onClick={() => setFilterStatus(status)}
              >
                {statusLabels[status]}
              </Button>
            ))}
          </div>
        </div>
      </div>

      {/* Счетчик результатов */}
      <div className="max-w-3xl text-sm ml-auto mr-auto text-gray-600 px-4">
        Показано {filteredPoints.length} из {points.length} точек
      </div>

      {/* Список точек */}
      <div className="space-y-3">
        {filteredPoints.length > 0 ? (
          filteredPoints.map((point) => (
            <div key={point.id} className="flex justify-center">
              <PointCard {...point} onClick={() => handlePointClick(point)} />
            </div>
          ))
        ) : (
          <div className="text-center text-gray-500 py-8">
            Нет доступных точек
          </div>
        )}
      </div>

      {/* Drawer для детального просмотра */}
      <Drawer open={isDrawerOpen} onOpenChange={setIsDrawerOpen}>
        <DrawerContent>
          <DrawerHeader>
            <DrawerTitle className="text-left">
              {selectedPoint?.address}
            </DrawerTitle>
            <DrawerDescription className="text-left">
              Подробная информация о точке
            </DrawerDescription>
          </DrawerHeader>

          <div className="px-4 pb-4 space-y-4">
            {selectedPoint && (
              <>
                <div className="space-y-2">
                  <h4 className="font-medium text-gray-900">Описание:</h4>
                  {/* <p className="text-gray-700">{selectedPoint.description}</p> */}
                  <Textarea
                    placeholder="Более точная информация"
                    value={selectedPoint?.description || ''}
                    onChange={(e) => {
                      if (selectedPoint) {
                        setSelectedPoint({
                          ...selectedPoint,
                          description: e.target.value,
                        });
                      }
                    }}
                  />
                </div>

                <div className="space-y-2">
                  <h4 className="font-medium text-gray-900">Дата создания:</h4>
                  <p className="text-gray-600">
                    {new Date(selectedPoint.date)
                      .toLocaleString('ru-RU', {
                        timeZone: 'Asia/Krasnoyarsk',
                        day: '2-digit',
                        month: '2-digit',
                        year: 'numeric',
                        hour: '2-digit',
                        minute: '2-digit',
                      })
                      .replace(',', '')}
                  </p>
                </div>

                <div className="space-y-2">
                  <h4 className="font-medium text-gray-900">Статус:</h4>
                  <div className="flex">
                    <Badge
                      variant="default"
                      className={`${
                        selectedPoint.status === 'pending'
                          ? 'bg-gray-400'
                          : selectedPoint.status === 'queued'
                          ? 'bg-blue-500'
                          : selectedPoint.status === 'in_progress'
                          ? 'bg-yellow-400 text-neutral-900'
                          : selectedPoint.status === 'completed'
                          ? 'bg-green-600'
                          : 'border-red-500 text-red-500'
                      } rounded-md`}
                    >
                      {selectedPoint.status === 'pending'
                        ? 'на рассмотрении'
                        : selectedPoint.status === 'queued'
                        ? 'в очереди'
                        : selectedPoint.status === 'in_progress'
                        ? 'в работе'
                        : selectedPoint.status === 'completed'
                        ? 'выполнено'
                        : 'удалено'}
                    </Badge>
                  </div>
                </div>
              </>
            )}
          </div>

          <DrawerFooter>
            <DrawerClose asChild>
              <Button variant="outline" onClick={handleDrawerClose}>
                Закрыть
              </Button>
            </DrawerClose>
          </DrawerFooter>
        </DrawerContent>
      </Drawer>
    </div>
  );
}
