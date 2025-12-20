import sqlite3 from 'sqlite3';
import { open } from 'sqlite';

const CREATE_POINTS_TABLE = `
  CREATE TABLE IF NOT EXISTS points (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    description TEXT NOT NULL,
    address TEXT,
    status TEXT DEFAULT 'new',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
  )`;

// todo: try-catch, logging

export async function initDb() {
  const db = await open({
    filename: './database.db',
    driver: sqlite3.Database
  });

  await db.run(CREATE_POINTS_TABLE);

  return db;
}
