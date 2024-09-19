export default function convertIsoToDateInputFormat(isoDate:string) {
    // Crear un objeto Date a partir de la fecha ISO
    const date = new Date(isoDate);

    // Obtener el año, mes y día del objeto Date
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Meses comienzan en 0
    const day = String(date.getDate()).padStart(2, '0');

    // Formatear la fecha en el formato yyyy-mm-dd
    return `${year}-${month}-${day}`;
}