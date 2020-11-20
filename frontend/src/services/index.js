import axios from 'axios'
import { PermisoService } from '@/services/permiso'
import { TipoPermisoService } from '@/services/tipoPermiso'

export default {
  permisoService: new PermisoService(axios),
  tipoPermisoService: new TipoPermisoService(axios)
}
