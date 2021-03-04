import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  myKeeps: [],
  myVaults: [],
  keeps: [],
  vaults: [],
  activeVault: {},
  activeVaultKeeps: [],
  activeKeep: {},
  viewedProfile: {},
  profileKeeps: [],
  profileVaults: []
})
