import * as repo from '../db/points.repo.js';

function validatePoint(data) {
  // Basic validation for point data
}

// Функция для преобразования snake_case в camelCase
function transformPointForApi(dbPoint) {
  return {
    id: dbPoint.id,
    description: dbPoint.description,
    address: dbPoint.address,
    status: dbPoint.status,
    createdAt: dbPoint.created_at,
  };
}

export async function getAllPoints(db) {
  const dbPoints = await repo.getAllPointsWithoutDeleted(db);
  return dbPoints.map(transformPointForApi);
}

export async function getPointById(db, id) {
  const dbPoint = await repo.getPointById(db, id);
  return transformPointForApi(dbPoint);
}

export async function createPoint(db, data) {
  const result = await repo.createPoint(db, data);
  const newPoint = await repo.getPointById(db, result.lastID);
  return transformPointForApi(newPoint);
}

export async function updatePoint(db, id, data) {
  // todo: validation
  await repo.updatePoint(db, id, data);
  const updatedPoint = await repo.getPointById(db, id);
  return updatedPoint;
}

export async function deletePoint(db, id) {
  return await repo.deletePoint(db, id);
}
