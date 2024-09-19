import React from 'react';
import { Task } from '../models/Task';

interface TaskItemProps {
  task: Task;
  onClick: () => void;
}

const TaskItem: React.FC<TaskItemProps> = ({ task, onClick }) => {
  return (
    <div 
      className="p-4 border border-gray-300 rounded cursor-pointer hover:bg-gray-100"
      onClick={onClick}
    >
      <h2 className="text-xl font-bold">{task.Name}</h2>
      <p className="text-gray-700">{task.Description}</p>
    </div>
  );
};

export default TaskItem;
