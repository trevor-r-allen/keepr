const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async getKeepById(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data
  }

  async createKeep(keep) {
    const res = await api.post('api/keeps', keep)
    AppState.myKeeps.push = res.data
  }

  async editKeep(id, editedKeep) {
    const res = await api.put('api/keeps/' + id, editedKeep)
    const index = AppState.myKeeps.indexOf(keep => keep.id === id)
    AppState.myKeeps = AppState.myKeeps.splice(index, 1, res.data)
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    AppState.myKeeps = AppState.myKeeps.filter(keep => !(keep.id === id))
  }
}

export const keepsService = new KeepsService()
