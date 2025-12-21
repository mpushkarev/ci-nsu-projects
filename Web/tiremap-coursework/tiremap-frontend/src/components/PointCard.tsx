import { Card, CardContent } from '@/components/ui/card';
import { Badge } from '@/components/ui/badge';
import type { Point } from '@/types/point';
import {
  MdLocationPin,
  MdFormatAlignLeft,
  MdCalendarToday,
} from 'react-icons/md';

const statusConfig = {
  pending: {
    variant: 'default' as const,
    className: 'rounded-md bg-gray-400',
    text: 'на рассмотрении',
  },
  queued: {
    variant: 'default' as const,
    className: 'rounded-md bg-blue-500',
    text: 'в очереди',
  },
  in_progress: {
    variant: 'default' as const,
    className: 'rounded-md bg-yellow-400 text-neutral-900',
    text: 'в работе',
  },
  completed: {
    variant: 'default' as const,
    className: 'rounded-md bg-green-600',
    text: 'выполнено',
  },
  deleted: {
    variant: 'outline' as const,
    className: 'rounded-md border-red-500 text-red-500',
    text: 'удалено',
  },
};

interface PointCardProps extends Point {
  onClick?: () => void;
}

export function PointCard({ onClick, ...point }: PointCardProps) {
  return (
    <Card
      className="w-full max-w-3xl p-4 cursor-pointer hover:shadow-lg transition-shadow"
      onClick={onClick}
    >
      <CardContent className="space-y-1 p-0">
        <div className="flex items-center gap-1">
          <MdLocationPin className="text-lg text-gray-600" />
          <span className="font-medium text-lg truncate max-w-[90%]">
            {point.address}
          </span>
        </div>
        <div className="flex gap-1">
          <MdFormatAlignLeft className="text-lg text-gray-600 mt-[0.15rem]" />
          <span className="text-gray-700 line-clamp-2 max-w-[90%]">
            {point.description}
          </span>
        </div>
        <div className="flex items-center justify-between">
          <div className="flex items-center gap-1">
            <MdCalendarToday className="text-lg text-gray-600" />
            <span className="text-gray-500">
              {new Date(point.date)
                .toLocaleString('ru-RU', {
                  timeZone: 'Asia/Krasnoyarsk',
                  day: '2-digit',
                  month: '2-digit',
                  year: 'numeric',
                  hour: '2-digit',
                  minute: '2-digit',
                })
                .replace(',', '')}
            </span>
          </div>
          <Badge
            variant={statusConfig[point.status].variant}
            className={statusConfig[point.status].className}
          >
            {statusConfig[point.status].text}
          </Badge>
        </div>
      </CardContent>
    </Card>
  );
}
