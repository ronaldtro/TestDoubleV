import React, { useState } from 'react';
import Swal from 'sweetalert2';
import { register } from '../services/authService';
import { setToken } from '../utilities/auth';
import { useNavigate } from 'react-router-dom';
import { postUserRol } from '../services/userService';


const AuthForm = () => {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [username, setUsername] = useState('');
  const [names, setNames] = useState('');
  const [lastNames, setLastNames] = useState('');
  const [dateOfBirth, setDateOfBirth] = useState('');
  const [rolId, setRolId] = useState('');

  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    try {

      const response = await register(email, username,
        password, names, lastNames, dateOfBirth);
      console.log(response);

      const response2 = await postUserRol(response.data.userId, rolId);

      if (response.success && response2.success) {

        navigate('/dashboard');

        console.log(response);

        const Toast = Swal.mixin({
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          timer: 3000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer
            toast.onmouseleave = Swal.resumeTimer
          },
        })
        Toast.fire({
          icon: 'success',
          title: "usuario creado exitosamente",
        });

      } else {
        console.log(response);

        const Toast = Swal.mixin({
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          timer: 3000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.onmouseenter = Swal.stopTimer
            toast.onmouseleave = Swal.resumeTimer
          },
        })
        Toast.fire({
          icon: 'error',
          title: "Ha ocurrido un error al realizar el registro",
        })
      }
    } catch (error: any) {


      console.log('Error Message:', error.message);


      const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        didOpen: (toast) => {
          toast.onmouseenter = Swal.stopTimer
          toast.onmouseleave = Swal.resumeTimer
        },
      })
      Toast.fire({
        icon: 'error',
        title: "Server error: " + error.message,
      })
    }

  };

  return (
    <div>
      <div className="flex justify-center items-center p-10">
        <p className="justify-center bg-blue-400 rounded-md p-2 text-white">Registro usuarios</p>
      </div>
      <form onSubmit={handleSubmit} className="space-y-4">
        <div className="flex justify-center items-center gap-3">
          <div>
            <label htmlFor='email'>Email</label>
          </div>
          <input
            type="email"
            id="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            className="p-2 border border-gray-300 rounded"
            required
          />
        </div>
        <div className="flex justify-center items-center gap-3">
          <div>
            <label htmlFor='password'>Password</label>
          </div>
          <input
            type="password"
            id='password'
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="p-2 border border-gray-300 rounded"
            required
          />
        </div>
        <div className="flex justify-center items-center gap-3">
          <div>
            <label htmlFor='username'>Username</label>
          </div>
          <input
            type="text"
            id="username"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            className="p-2 border border-gray-300 rounded"
            required
          />
        </div>
        <div className="flex justify-center items-center gap-3">
          <div>
            <label htmlFor='names'>Nombres</label>
          </div>
          <input
            type="text"
            id="names"
            placeholder="First Names"
            value={names}
            onChange={(e) => setNames(e.target.value)}
            className="p-2 border border-gray-300 rounded"
            required
          />
        </div>
        <div className="flex justify-center items-center gap-3">
          <div>
            <label htmlFor='lastnames'>Apellidos</label>
          </div>
          <input
            type="text"
            id="lastnames"
            placeholder="Last Names"
            value={lastNames}
            onChange={(e) => setLastNames(e.target.value)}
            className="p-2 border border-gray-300 rounded"
            required
          />
        </div>
        <div className="flex justify-center items-center gap-3">
          <div>
            <label htmlFor='date'>Fecha de nacimiento</label>
          </div>
          <input
            type="date"
            id="date"
            placeholder="Fecha de nacimiento"
            value={dateOfBirth}
            onChange={(e) => setDateOfBirth(e.target.value)}
            className="p-2 border border-gray-300 rounded"
            required
          />
        </div>
        <div className="flex justify-center items-center gap-3">

          <div>
            <label htmlFor='rol'>Rol</label>
          </div>
          <select
            className="form-select select-sm"
            id="rol"
            name="rol"
            value={rolId}
            onChange={(e) => setRolId(e.target.value)}
            aria-label="Default select example">
            <option
              value="">Seleccione</option>
            <option
              value="1">Administrador</option>
            <option
              value="2">Supervisor</option>
            <option
              value="3">Empleado</option>
          </select>
        </div>


        <div className="flex justify-center items-center">
          <button type="submit" className="p-2 bg-blue-500 text-white rounded">
            Guardar cambios
          </button>
        </div>

      </form>
    </div>
  );
};

export default AuthForm;
