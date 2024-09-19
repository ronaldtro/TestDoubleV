import { useEffect, useState } from "react";
import { deleteUser, getUsers, updateUser } from "../services/userService";
import Swal from "sweetalert2";
import { useNavigate } from 'react-router-dom';
import { User } from "../models/User";
import convertIsoToDateInputFormat from "../utilities/formatDate";

interface UserForm{
    username: string,
    email: string,
    names: string,
    lastNames: string,
    dateOfBirth: string
}

export default function UsersManagement() {
    // value={dateOfBirth}
    // onChange={(e) => setDateOfBirth(e.target.value)}

    const navigate = useNavigate();
    const [users, setusers] = useState<User[]>([]);
    const [activeModal, setActiveModal] = useState<boolean>(false);
    const [userForm, setUserForm] = useState<UserForm>({
        username: "",
        email: "",
        names: "",
        lastNames: "",
        dateOfBirth: "",
    });
    const [selectedUser, setSelectedUser] = useState("");

    useEffect(() => {
        const req = async () => {
            try {
                const response = await getUsers();

                if (response.success) {

                    console.log(response);
                    setusers(response.data);

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
                        title: "Ha ocurrido un error",
                    })
                }
            } catch (error: any) {
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
        req();
    }, []);

    const handleChange = (event: any) => {
        const { name, value } = event.target
        setUserForm({
            ...userForm,
            [name]: value,
        })
    }

    const handleDeleteUser = async (id: string) => {

        try {
            await deleteUser(id);
            setusers(users.filter(user => user.userId !== id));

            Swal.fire({
                icon: 'success',
                title: 'Deleted',
                text: 'User successfully deleted',
                toast: true,
                position: 'top-end',
                timer: 3000,
                timerProgressBar: true,
            });
        } catch (error: any) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Server error: ' + error.message,
                toast: true,
                position: 'top-end',
                timer: 3000,
                timerProgressBar: true,
            });
        }
    };

    const handlePutUser = async (e:any) => {

        e.preventDefault();

        try {
    
            await updateUser(selectedUser,  userForm);

            setusers(users.map(u => u.userId == selectedUser ? {...u, userForm} : u));

            Swal.fire({
                icon: 'success',
                text: 'Operacion exitosa',
                toast: true,
                position: 'top-end',
                timer: 3000,
                timerProgressBar: true,
            });

        } catch (error: any) {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: 'Server error: ' + error.message,
                toast: true,
                position: 'top-end',
                timer: 3000,
                timerProgressBar: true,
            });
        }
    };

    const selectUser = (user:User) => {
        setUserForm({
            username: user.username,
            email: user.email,
            names: user.names,
            lastNames: user.lastNames,
            dateOfBirth: convertIsoToDateInputFormat(user.dateOfBirth),
        });
        setSelectedUser(user.userId);
        setActiveModal(true);
    }

    return (
        <>
            {activeModal ? <>
                <div
                    className="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity"
                    aria-hidden="true"
                    onClick={() => setActiveModal(false)}
                ></div>
                <div className="fixed inset-0 flex items-center justify-center p-4">
                    <div className="bg-white rounded-lg shadow-lg max-w-sm w-full p-6">
                        <h3 className="text-lg font-semibold mb-4">Usuario</h3>
                        <form onSubmit={handlePutUser}>
                            <div className="mb-4">
                                <label htmlFor="username" className="block text-sm font-medium
                                 text-gray-700">username</label>
                                <input
                                    type="text"
                                    id="username"
                                    name="username"
                                    value={userForm.username}
                                    onChange={handleChange}
                                    className="mt-1 block w-full border border-gray-300 rounded-md
                                    shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
                                    placeholder="username"
                                />
                            </div>
                            <div className="mb-4">
                                <label htmlFor="email" className="block text-sm font-medium 
                                text-gray-700">Email</label>
                                <input
                                    type="email"
                                    id="email"
                                    name="email"
                                    value={userForm.email}
                                    onChange={handleChange}
                                    className="mt-1 block w-full border border-gray-300 rounded-md 
                                    shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
                                    placeholder="Email"
                                />
                            </div>
                            <div className="mb-4">
                                <label htmlFor="names" className="block text-sm font-medium 
                                text-gray-700">Nombres</label>
                                <input
                                    type="text"
                                    id="names"
                                    name="names"
                                    value={userForm.names}
                                    onChange={handleChange}
                                    className="mt-1 block w-full border border-gray-300 rounded-md 
                                    shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
                                    placeholder="Nombres"
                                />
                            </div>
                            <div className="mb-4">
                                <label htmlFor="lastnames" className="block text-sm font-medium 
                                text-gray-700">Apellidos</label>
                                <input
                                    type="text"
                                    id="lastNames"
                                    name="lastNames"
                                    value={userForm.lastNames}
                                    onChange={handleChange}
                                    className="mt-1 block w-full border border-gray-300 rounded-md 
                                    shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
                                    placeholder="Apellidos"
                                />
                            </div>
                            <div className="mb-4">
                                <label htmlFor="dateOfBirth" className="block text-sm font-medium 
                                text-gray-700">Fecha de nacimiento</label>
                                <input
                                    type="date"
                                    id="dateOfBirth"
                                    name="dateOfBirth"
                                    value={userForm.dateOfBirth}
                                    onChange={handleChange}
                                    className="mt-1 block w-full border border-gray-300 rounded-md 
                                    shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
                                    placeholder="Fecha de nacimiento"
                                />
                            </div>
                            <div className="flex justify-end gap-4">
                                <button
                                    type="button"
                                    className="inline-flex items-center px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-gray-500 hover:bg-gray-600"
                                    onClick={() => setActiveModal(false)}
                                >
                                    Cancelar
                                </button>
                                <button
                                    type="submit"
                                    className="inline-flex items-center px-4 py-2 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-500 hover:bg-blue-600"
                                >
                                    Guardar
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </> : ""}

            <div className="overflow-x-auto">
                <table className="min-w-full bg-white border border-gray-200 rounded-lg">
                    <thead className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
                        <tr>
                            <th className="py-3 px-6 text-left">user_Id</th>
                            <th className="py-3 px-6 text-left">names</th>
                            <th className="py-3 px-6 text-center">lastNames</th>
                            <th className="py-3 px-6 text-center">email</th>
                            <th className="py-3 px-6 text-center">dateOfBirth</th>
                            <th className="py-3 px-6 text-center">Options</th>
                        </tr>
                    </thead>
                    <tbody className="text-gray-600 text-sm font-light">
                        {users.map((user) => (
                            <tr key={user.userId} className="border-b border-gray-200 hover:bg-gray-100">
                                <td className="py-3 px-6 text-left">{user.userId}</td>
                                <td className="py-3 px-6 text-left">{user.names}</td>
                                <td className="py-3 px-6 text-left">{user.lastNames}</td>
                                <td className="py-3 px-6 text-left">{user.email}</td>
                                <td className="py-3 px-6 text-left">{user.dateOfBirth}</td>
                                <td className="py-3 px-6 text-left">
                                    <div className="flex justify-center items-center gap-3">
                                        <button onClick={() => selectUser(user)} className="p-2 bg-orange-500 text-white rounded">
                                            Editar
                                        </button>
                                        <button onClick={() => handleDeleteUser(user.userId)} className="p-2 bg-red-500 text-white rounded">
                                            Eliminar
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

        </>);
}