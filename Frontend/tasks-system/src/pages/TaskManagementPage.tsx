import React, { useEffect, useState } from 'react';
import TaskList from '../components/TaskList';
import { getTasks } from '../services/taskService';
import { Task } from '../models/Task';

const TaskManagementPage: React.FC = () => {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchTasks = async () => {
      try {
        const response = await getTasks();
        if (response.success) {
          setTasks(response.data);
        } else {
          setError('Failed to fetch tasks');
        }
      } catch (err) {
        setError('An error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchTasks();
  }, []);

  const handleTaskClick = (taskId: string) => {
    // Implement navigation or actions on task click
    console.log(`Task ${taskId} clicked`);
  };

  return (
    <div className="p-6">
      <h1 className="text-2xl font-bold mb-4">Task Management</h1>
      {loading && <p>Loading...</p>}
      {error && <p className="text-red-500">{error}</p>}
      <TaskList tasks={tasks} onTaskClick={handleTaskClick} />
    </div>
  );
};

export default TaskManagementPage;
