import * as repo from '../db/points.repo.js';

function validatePoint(data) {
  // Basic validation for point data
}

export async function getAllPoints(db) {
  return await repo.getAllPoints(db);
}

export async function getPointById(db, id) {
  return await repo.getPointById(db, id);
}

export async function createPoint(db, data) {
  const result = await repo.createPoint(db, data);
  const newPoint = await repo.getPointById(db, result.lastID);
  return newPoint;
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
