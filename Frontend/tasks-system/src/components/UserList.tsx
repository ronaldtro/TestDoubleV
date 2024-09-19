import React from 'react';
import { User } from '../models/User';
import UserItem from './UserItem';

interface UserListProps {
  users: User[];
  onUserClick: (userId: string) => void;
}

const UserList: React.FC<UserListProps> = ({ users, onUserClick }) => {
  return (
    <div className="space-y-4">
      {users.map(user => (
        <UserItem key={user.userId} user={user} onClick={() => onUserClick(user.userId)} />
      ))}
    </div>
  );
};

export default UserList;
