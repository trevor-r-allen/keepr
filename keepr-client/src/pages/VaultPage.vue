<template>
  <div class="home flex-grow-1 container-fluid">
    <h1>{{ state.activeVault.name }}</h1>
    <div class="masonry justify-content-around mt-5">
      <keep-component v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeVault: computed(() => AppState.activeVault),
      activeVaultKeeps: computed(() => AppState.activeVaultKeeps)
    })
    onMounted(() => {
      vaultsService.getVaultById(route.params.id)
      vaultsService.getKeepsByVaultId(route.params.id)
    })
    return {
      state
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
