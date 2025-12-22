import express from 'express';

import { pointsRouter } from './routes/points.js';

// function mapPoint(point) {
//   return {
//     id: point.id,
//     description: point.description,
//     address: point.address,
//     status: point.status,
//     createdAt: point.created_at
//   };
// }

export function createApp(db) {
  const app = express();

  app.use(express.json());

  app.get('/healthz', (req, res) => {
    res.json({ status: 'ok' });
  });

  app.use((req, res, next) => {
    res.header('Access-Control-Allow-Origin', '*');
    res.header('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE');
    res.header('Access-Control-Allow-Headers', 'Content-Type, Authorization');
    next();
  });

  app.use('/points', pointsRouter(db));

  // app.get('/items', async (req, res) => {
  //   try {
  //     const rows = await db.all(
  //       `SELECT id, description, address, status, created_at
  //       FROM points`
  //     );
  //     console.log('Found rows:', rows.length);
  //     res.json(rows.map(mapPoint));
  //   } catch (error) {
  //     console.error('Database query error:', error);
  //     res.status(500).json({ error: 'Internal server error' });
  //   }
  // });

  // app.get('/items/:id', (req, res) => {
  //   const itemId = parseInt(req.params.id, 10);
  //   const item = items.find(i => i.id === itemId);

  //   if (item) {
  //     res.json(item);
  //   } else {
  //     res.status(404).json({ error: 'Item not found' });
  //   }
  // });

  // app.post('/items', async (req, res) => {
  //   const { description, address } = req.body;

  //   if (!description) {
  //     return res.status(400).json({ error: 'Description is required' });
  //   }

  //   try {
  //     const result = await db.run(
  //       `INSERT INTO points (description, address) VALUES (?, ?)`,
  //       description,
  //       address
  //     );

  //     const createdItem = await db.get(
  //       `SELECT id, description, address, status, created_at
  //       FROM points WHERE id = ?`,
  //       result.lastID
  //     );

  //     res.status(201).json(mapPoint(createdItem));
  //   } catch (error) {
  //     console.error(error);
  //     res.status(500).json({ error: 'Internal server error' });
  //   }
  // });

  // app.patch('/items/:id', (req, res) => {
  //   const itemId = parseInt(req.params.id, 10);
  //   const { address, description } = req.body;

  //   const itemIndex = items.findIndex(i => i.id === itemId);
  //   const item = items[itemIndex];

  //   if (itemIndex !== -1) {
  //     if (address) item.address = address;
  //     if (description) item.description = description;
  //     items[itemIndex] = item;
  //     res.json(items[itemIndex]);
  //   } else {
  //     res.status(404).json({ error: 'Item not found' });
  //   }
  // });

  // app.delete('/items/:id', (req, res) => {
  //   const itemId = parseInt(req.params.id, 10);
  //   const itemIndex = items.findIndex(item => item.id === itemId);

  //   if (itemIndex !== -1) {
  //     items.splice(itemIndex, 1);
  //     res.status(204).end();
  //   } else {
  //     res.status(404).json({ error: 'Item not found' });
  //   }
  // });

  app.use((req, res) => {
    res.status(404).json({ error: 'Route not found' });
  });

  return app;
}
