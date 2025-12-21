export interface Point {
  id: string;
  address: string;
  description: string;
  date: string;
  status: 'pending' | 'queued' | 'in_progress' | 'completed' | 'deleted';
}

export type FilterStatus = Point['status'] | 'all';
