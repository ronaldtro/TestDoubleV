# Test - Double V
Hola, en este repositorio podran encontrar el backend y frontend correspondiente a la prueba tecnica.

## Tabla de contenido
- [Introduccion](#introduccion)
- [Licencia](#licencia)

## Introduccion
La webApp fue realizada con: 
React 18, Tailwind css, Asp.net 8 con entity framework y sqlServer.

Frontend:
- Permite al usuario administrador crear usuarios con roles, editar usuarios y eliminarlos.
- Iniciar sesion y manejo de jwt.
- Visualizar usuarios, entre otras.

Backend:
- Cumple todo el ciclo de vida de la prueba, incluyendo validaciones, jwt y expiracion del mismo.

DB:
- El script de la db se encuentra dentro del proyecto.

run frontend
```bash
npm run dev
```
run backend
```bash
Cargar el script de la base de datos en el motor sqlserver
Configurar la cadena de conexion en local en la solucion
Compilar la solucion
```

## Licencia
Este proyecto es de codigo abierto y esta licenciado bajo [MIT](/LICENSE).
