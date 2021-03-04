import { api } from './AxiosService'
import { vaultsService } from './VaultsService'

class VaultKeepsService {
  async createVaultKeep(vaultKeep) {
    const res = await api.post('api/vaultkeeps', vaultKeep)
    vaultsService.getKeepsByVaultId(res.data.vaultId)
  }

  async deleteVaultKeep(id) {
    await api.delete('api/vaultkeeps/' + id)
  }
}

export const vaultKeepsService = new VaultKeepsService()
