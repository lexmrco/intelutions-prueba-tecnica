export class TipoPermisoService {
  axios
  baseUrl

  constructor (axios) {
    this.axios = axios
    this.baseUrl = process.env.VUE_APP_API_URL
  }

  getSelectListItems () {
    return this.axios.get(this.baseUrl + '/tipospermisos/selectlist')
  }
}
