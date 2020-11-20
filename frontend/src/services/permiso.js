export class PermisoService {
  axios
  baseUrl

  constructor (axios) {
    this.axios = axios
    this.baseUrl = process.env.VUE_APP_API_URL
  }

  getItems () {
    return this.axios.get(this.baseUrl + '/permisos')
  }

  postItem (item) {
    return this.axios.post(this.baseUrl + '/permisos', {
      nombreEmpleado: item.nombreEmpleado,
      apellidosEmpleado: item.apellidosEmpleado,
      tipoPermisoId: parseInt(item.tipoPermisoId),
      fechaPermiso: item.fechaPermiso
    })
  }

  putItem (item) {
    return this.axios.put(`${this.baseUrl}/permisos/${item.id}`, {
      nombreEmpleado: item.nombreEmpleado,
      apellidosEmpleado: item.apellidosEmpleado,
      tipoPermisoId: parseInt(item.tipoPermisoId),
      fechaPermiso: item.fechaPermiso
    })
  }

  deleteItem (id) {
    return this.axios.delete(`${this.baseUrl}/permisos/${id}`)
  }
}
