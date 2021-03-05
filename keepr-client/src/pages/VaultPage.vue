<template>
  <div class="home flex-grow-1 container-fluid">
    <div class="row mt-5">
      <div class="col">
        <h1>
          {{ state.activeVault.name }} <i v-if="(state.user.isAuthenticated && state.activeVault.creatorId === state.account.id)" @click="deleteVault(state.activeVault.id)" class="fa fa-trash text-danger" aria-hidden="true"></i>
        </h1>
      </div>
    </div>
    <div class="masonry justify-content-around mt-5">
      <keep-component v-for="keep in state.activeVaultKeeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { onBeforeRouteLeave, useRoute } from 'vue-router'
import router from '../router'
import NotificationsService from '../services/NotificationsService'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      activeVault: computed(() => AppState.activeVault),
      activeVaultKeeps: computed(() => AppState.activeVaultKeeps)
    })
    async function deleteVault(vaultId) {
      if (await NotificationsService.confirmAction()) {
        await vaultsService.deleteVault(vaultId)
        router.push({ name: 'Profile', params: { id: state.account.id } })
        AppState.activeVault = {}
        AppState.activeVaultKeeps = []
      }
    }
    onMounted(() => {
      vaultsService.getVaultById(route.params.id)
      vaultsService.getKeepsByVaultId(route.params.id)
    })
    onBeforeRouteLeave(() => {
      AppState.activeVault = {}
      AppState.activeVaultKeeps = []
    })
    return {
      state,
      deleteVault
    }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/css/global.css";

.fa-trash:hover{
  cursor: pointer;
}
</style>
