import { Link, useLocation } from 'react-router-dom';

function TabNavigation() {

  const location = useLocation();
  
  return (
    <div className="fixed bottom-0 left-0 right-0 bg-white border-t flex">
      <Link 
        to="/map"
        replace
        className={`flex-1 py-4 text-center ${
          location.pathname === '/map' 
            ? 'bg-blue-500 text-white'
            : 'bg-gray-200 hover:bg-gray-300'
        }`}>
        Карта
      </Link>
      <Link 
        to="/list"
        replace
        className={`flex-1 py-4 text-center ${
          location.pathname === '/list' 
            ? 'bg-blue-500 text-white' 
            : 'bg-gray-200 hover:bg-gray-300'
        }`}>
        Список
      </Link>
    </div>
  );
}

export default TabNavigation;
