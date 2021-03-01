const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }
}

export const keepsService = new KeepsService()
