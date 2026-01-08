import express from 'express';
import * as service from '../services/points.service.js';

export function pointsRouter(db) {
  const router = express.Router();

  router.get('/', async (req, res) => {
    // Fetch all points
    const points = await service.getAllPoints(db);
    res.json(points);
  });

  router.get('/:id', async (req, res) => {
    // Fetch point by ID
    const point = await service.getPointById(db, req.params.id);
    res.json(point);
  });

  router.post('/', async (req, res) => {
    // Create a new point
    const newPoint = await service.createPoint(db, req.body);
    res.json(newPoint);
  });

  router.patch('/:id', async (req, res) => {
    // Update point by ID
    const updatedPoint = await service.updatePoint(db, req.params.id, req.body);
    res.json(updatedPoint);
  });

  router.delete('/:id', async (req, res) => {
    // Delete point by ID
    await service.deletePoint(db, req.params.id);
    res.status(204).end();
  });

  return router;
}
