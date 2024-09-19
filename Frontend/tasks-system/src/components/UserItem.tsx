import React from 'react';
import { User } from '../models/User';

interface UserItemProps {
  user: User;
  onClick: () => void;
}

const UserItem: React.FC<UserItemProps> = ({ user, onClick }) => {
  return (
    <div 
      className="p-4 border border-gray-300 rounded cursor-pointer hover:bg-gray-100"
      onClick={onClick}
    >
      <h2 className="text-xl font-bold">{user.username}</h2>
      <p className="text-gray-700">{user.names} {user.lastNames}</p>
      <p className="text-gray-500">{user.email}</p>
    </div>
  );
};

export default UserItem;
