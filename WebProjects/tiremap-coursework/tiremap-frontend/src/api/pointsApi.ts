const API_BASE_URL = 'http://192.168.1.55:3000';

// Простая функция для получения точек
export const getAllPoints = async () => {
  const response = await fetch(`${API_BASE_URL}/points`);

  if (!response.ok) {
    throw new Error(`Ошибка: ${response.status}`);
  }

  const data = await response.json();
  return data;
};
