import { useState } from 'react';
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
import { Badge } from '@/components/ui/badge';
import type { Point } from '@/types/point';
import {
  MdLocationPin,
  MdFormatAlignLeft,
  MdCalendarToday,
  MdEdit,
  MdDelete,
} from 'react-icons/md';

interface PointDetailsDrawerProps {
  point: Point | null;
  isOpen: boolean;
  onClose: () => void;
  onEdit?: (point: Point) => void;
  onDelete?: (point: Point) => void;
}

const statusConfig = {
  pending: { className: 'bg-gray-400', text: 'на рассмотрении' },
  queued: { className: 'bg-blue-500', text: 'в очереди' },
  in_progress: {
    className: 'bg-yellow-400 text-neutral-900',
    text: 'в работе',
  },
  completed: { className: 'bg-green-600', text: 'выполнено' },
  deleted: { className: 'border-red-500 text-red-500', text: 'удалено' },
};

/**
 * Оптимизированный компонент для отображения детальной информации о точке в Drawer
 * Рендерится только когда открыт, что экономит ресурсы
 */
export function PointDetailsDrawer({
  point,
  isOpen,
  onClose,
  onEdit,
  onDelete,
}: PointDetailsDrawerProps) {
  const [isActionLoading, setIsActionLoading] = useState(false);

  if (!point) return null;

  const handleEdit = async () => {
    if (!onEdit) return;
    setIsActionLoading(true);
    try {
      onEdit(point);
      onClose();
    } finally {
      setIsActionLoading(false);
    }
  };

  const handleDelete = async () => {
    if (!onDelete) return;
    setIsActionLoading(true);
    try {
      onDelete(point);
      onClose();
    } finally {
      setIsActionLoading(false);
    }
  };

  return (
    <Drawer open={isOpen} onOpenChange={onClose}>
      <DrawerContent>
        <DrawerHeader>
          <DrawerTitle className="text-left flex items-center gap-2">
            <MdLocationPin className="text-xl text-gray-600" />
            {point.address}
          </DrawerTitle>
          <DrawerDescription className="text-left">
            Подробная информация о точке #{point.id}
          </DrawerDescription>
        </DrawerHeader>

        <div className="px-4 pb-4 space-y-6 max-h-[60vh] overflow-y-auto">
          {/* Описание */}
          <div className="space-y-3">
            <div className="flex items-center gap-2">
              <MdFormatAlignLeft className="text-lg text-gray-600" />
              <h4 className="font-medium text-gray-900">Описание:</h4>
            </div>
            <p className="text-gray-700 pl-6 leading-relaxed">
              {point.description}
            </p>
          </div>

          {/* Дата создания */}
          <div className="space-y-3">
            <div className="flex items-center gap-2">
              <MdCalendarToday className="text-lg text-gray-600" />
              <h4 className="font-medium text-gray-900">Дата создания:</h4>
            </div>
            <p className="text-gray-600 pl-6">
              {new Date(`${point.createdAt.replace(' ', 'T')}Z`)
                .toLocaleString('ru-RU', {
                  timeZone: 'Asia/Novosibirsk',
                  day: '2-digit',
                  month: '2-digit',
                  year: 'numeric',
                  hour: '2-digit',
                  minute: '2-digit',
                })
                .replace(',', '')}
            </p>
          </div>

          {/* Статус */}
          <div className="space-y-3">
            <h4 className="font-medium text-gray-900">Текущий статус:</h4>
            <div className="pl-6">
              <Badge
                variant={point.status === 'deleted' ? 'outline' : 'default'}
                className={`${statusConfig[point.status].className} rounded-md`}
              >
                {statusConfig[point.status].text}
              </Badge>
            </div>
          </div>
        </div>

        <DrawerFooter>
          <div className="flex gap-2 w-full">
            {onEdit && point.status !== 'deleted' && (
              <Button
                variant="default"
                className="flex-1 flex items-center gap-2"
                onClick={handleEdit}
                disabled={isActionLoading}
              >
                <MdEdit className="text-sm" />
                Редактировать
              </Button>
            )}

            {onDelete && point.status !== 'deleted' && (
              <Button
                variant="destructive"
                className="flex-1 flex items-center gap-2"
                onClick={handleDelete}
                disabled={isActionLoading}
              >
                <MdDelete className="text-sm" />
                Удалить
              </Button>
            )}
          </div>

          <DrawerClose asChild>
            <Button variant="outline" onClick={onClose} className="w-full">
              Закрыть
            </Button>
          </DrawerClose>
        </DrawerFooter>
      </DrawerContent>
    </Drawer>
  );
}

/**
 * Пример использования в другом компоненте:
 *
 * const [selectedPoint, setSelectedPoint] = useState<Point | null>(null);
 * const [isDrawerOpen, setIsDrawerOpen] = useState(false);
 *
 * const handlePointClick = (point: Point) => {
 *   setSelectedPoint(point);
 *   setIsDrawerOpen(true);
 * };
 *
 * const handleEdit = (point: Point) => {
 *   // Логика редактирования
 *   console.log('Edit point:', point);
 * };
 *
 * const handleDelete = (point: Point) => {
 *   // Логика удаления
 *   console.log('Delete point:', point);
 * };
 *
 * return (
 *   <>
 *     {points.map(point => (
 *       <PointCard
 *         key={point.id}
 *         {...point}
 *         onClick={() => handlePointClick(point)}
 *       />
 *     ))}
 *
 *     <PointDetailsDrawer
 *       point={selectedPoint}
 *       isOpen={isDrawerOpen}
 *       onClose={() => setIsDrawerOpen(false)}
 *       onEdit={handleEdit}
 *       onDelete={handleDelete}
 *     />
 *   </>
 * );
 */
