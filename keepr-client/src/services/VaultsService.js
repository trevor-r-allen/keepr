const { AppState } = require('../AppState')
const { api } = require('./AxiosService')

class VaultsService {
  async getAllVaults() {
    const res = await api.get('api/vaults')
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get('api/vaults/' + id)
    AppState.activeVault = res.data
  }

  async getKeepsByVaultId(id) {
    const res = await api.get('api/vaults/' + id + '/keeps')
    AppState.activeVaultKeeps = res.data
  }

  async createVault(vault) {
    const res = await api.post('api/vaults', vault)
    AppState.myVaults.push(res.data)
    AppState.profileVaults.push(res.data)
  }

  async editVault(id, editedVault) {
    const res = await api.put('api/vaults/' + id, editedVault)
    const myIndex = AppState.myVaults.indexOf(vault => vault.id === id)
    AppState.myVaults = AppState.myVaults.splice(myIndex, 1, res.data)
    const index = AppState.profileVaults.indexOf(vault => vault.id === id)
    AppState.profileVaults = AppState.profileVaults.splice(index, 1, res.data)
  }

  async deleteVault(id) {
    await api.delete('api/vaults/' + id)
    AppState.myVaults = AppState.myVaults.filter(vault => !(vault.id === id))
  }
}

export const vaultsService = new VaultsService()
