import express from 'express';

import { items } from './data.js';

const app = express();
const PORT = process.env.PORT || 3000;

app.use(express.json());

app.get('/healthz', (req, res) => {
  res.json({ status: 'ok' });
});

app.get('/items', (req, res) => {
  res.json(items);
});

app.get('/items/:id', (req, res) => {
  const itemId = parseInt(req.params.id, 10);
  const item = items.find(i => i.id === itemId);

  if (item) {
    res.json(item);
  } else {
    res.status(404).json({ error: 'Item not found' });
  }
});

app.post('/items', (req, res) => {
  const { address, description } = req.body;

  const newItem = {
    id: items.length + 1,
    address,
    description,
    createdAt: new Date()
  };

  items.push(newItem);

  res.status(201).json(newItem);
});

app.patch('/items/:id', (req, res) => {
  const itemId = parseInt(req.params.id, 10);
  const { address, description } = req.body;

  const itemIndex = items.findIndex(i => i.id === itemId);
  const item = items[itemIndex];

  if (itemIndex !== -1) {
    if (address) item.address = address;
    if (description) item.description = description;
    items[itemIndex] = item;
    res.json(items[itemIndex]);
  } else {
    res.status(404).json({ error: 'Item not found' });
  }
});

app.delete('/items/:id', (req, res) => {
  const itemId = parseInt(req.params.id, 10);
  const itemIndex = items.findIndex(item => item.id === itemId);

  if (itemIndex !== -1) {
    items.splice(itemIndex, 1);
    res.status(204).end();
  } else {
    res.status(404).json({ error: 'Item not found' });
  }
});

app.use((req, res) => {
  res.status(404).json({ error: 'Route not found' });
});

app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
