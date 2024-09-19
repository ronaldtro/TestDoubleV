import React from 'react';

interface RoleSelectorProps {
  roles: string[]; // Lista de roles como strings, puede ajustarse según el modelo real.
  selectedRole: string;
  onRoleChange: (role: string) => void;
}

const RoleSelector: React.FC<RoleSelectorProps> = ({ roles, selectedRole, onRoleChange }) => {
  return (
    <div className="flex flex-col space-y-2">
      {roles.map(role => (
        <button
          key={role}
          className={`p-2 border rounded ${role === selectedRole ? 'bg-blue-500 text-white' : 'bg-white text-blue-500'}`}
          onClick={() => onRoleChange(role)}
        >
          {role}
        </button>
      ))}
    </div>
  );
};

export default RoleSelector;
