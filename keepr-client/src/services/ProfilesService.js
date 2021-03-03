import { AppState } from '../AppState'
import { api } from './AxiosService'

class ProfilesService {
  async getById(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.viewedProfile = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    AppState.profileKeeps = res.data
  }

  async getVaultsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.profileVaults = res.data
  }
}

export const profilesService = new ProfilesService()
