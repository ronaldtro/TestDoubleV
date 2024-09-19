import React from 'react';
import { Task } from '../models/Task';
import TaskItem from './TaskItem';

interface TaskListProps {
  tasks: Task[];
  onTaskClick: (taskId: string) => void;
}

const TaskList: React.FC<TaskListProps> = ({ tasks, onTaskClick }) => {
  return (
    <div className="space-y-4">
      {tasks.map((task, index) => (
        <TaskItem key={index} task={task} onClick={() => onTaskClick(task.TaskId)} />
      ))}
    </div>
  );
};

export default TaskList;
