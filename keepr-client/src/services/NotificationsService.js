import Swal from 'sweetalert2'
import { logger } from '../utils/Logger'

export default class NotificationsService {
  static async confirmAction(title = 'Are you sure?', text = 'This action is irreversible.', confirmButtonText = 'Delete') {
    try {
      const res = await Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        iconColor: '#D63031',
        showCancelButton: true,
        confirmButtonColor: '#D63031',
        cancelButtonColor: '#B2BEC3',
        confirmButtonText: confirmButtonText,
        reverseButtons: true
      })
      if (res.isConfirmed) {
        return true
      }
      return false
    } catch (error) {
      logger.error(error)
    }
  }
}
