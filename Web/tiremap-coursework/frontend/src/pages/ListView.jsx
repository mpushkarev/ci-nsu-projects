import { Button } from "@/components/ui/button"

function ListView() {
  return (
    <div className="h-screen flex">
      <div className="flex-1 bg-blue-200 p-6">
        <div className="text-center">
          <h1 className="text-3xl font-bold mb-4">📋 Список</h1>
          <div className="space-y-3">
            <div className="bg-white p-4 rounded shadow">Элемент списка 1</div>
            <div className="bg-white p-4 rounded shadow">Элемент списка 2</div>
            <div className="bg-white p-4 rounded shadow">Элемент списка 3</div>
            <Button variant="primary">Добавить элемент</Button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default ListView;
