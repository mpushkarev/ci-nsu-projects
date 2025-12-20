export async function getAllPoints(db) {
  return db.all(`SELECT * FROM points`);
}

export async function getPointById(db, id) {
  return db.get(`SELECT * FROM points WHERE id = ?`, id);
}

export async function createPoint(db, data) {
  return db.run(
    `INSERT INTO points (description, address) VALUES (?, ?)`,
    data.description,
    data.address
  );
}

export async function updatePoint(db, id, data) {
  const fields = [];
  const values = [];

  if (data.description) {
    fields.push('description = ?');
    values.push(data.description);
  }

  if (data.address) {
    fields.push('address = ?');
    values.push(data.address);
  }

  values.push(id);

  const query = `UPDATE points SET ${fields.join(', ')} WHERE id = ?`;
  return db.run(query, ...values);
}

// todo: soft delete

export async function deletePoint(db, id) {
  return db.run(`DELETE FROM points WHERE id = ?`, id);
}
