import { initDb } from './db.js';
import { createApp } from './app.js';

const PORT = process.env.PORT || 3000;

// todo: try-catch, logging, graceful shutdown

(async () => {
  const db = await initDb();
  const app = createApp(db);

  app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
  });
})();
