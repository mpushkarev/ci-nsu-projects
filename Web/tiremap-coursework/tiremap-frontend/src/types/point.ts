export interface Point {
  id: string;
  address: string;
  description: string;
  createdAt: string;
  status: 'pending' | 'queued' | 'in_progress' | 'completed' | 'deleted';
}

export type FilterStatus = Exclude<Point['status'], 'deleted'> | 'all';
