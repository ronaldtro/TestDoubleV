import React, { useEffect, useState } from 'react';
import UserList from '../components/UserList';
import { getUsers } from '../services/userService';
import { User } from '../models/User';

const UserManagementPage: React.FC = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await getUsers();
        if (response.success) {
          setUsers(response.data);
        } else {
          setError('Failed to fetch users');
        }
      } catch (err) {
        setError('An error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
  }, []);

  const handleUserClick = (userId: string) => {
    // Implement navigation or actions on user click
    console.log(`User ${userId} clicked`);
  };

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">User Management</h1>
      {loading && <p>Loading...</p>}
      {error && <p className="text-red-500">{error}</p>}
      <UserList users={users} onUserClick={handleUserClick} />
    </div>
  );
};

export default UserManagementPage;
