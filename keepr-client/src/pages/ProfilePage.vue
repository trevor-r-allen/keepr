<template>
  <div class="home flex-grow-1 container">
    <div class="profileInfo row mt-5">
      <div class="col-3">
        <img :src="state.viewedProfile.picture" alt="">
      </div>
      <div class="col-3">
        <h1>{{ state.viewedProfile.name }}</h1>
        <h6>Vaults: {{ state.viewedProfile.vaults }}</h6>
        <h6>Keeps: {{ state.viewedProfile.keeps }}</h6>
      </div>
    </div>
    <div class="profileVaults row">
      <div class="col">
        <h1>Vaults</h1>
      </div>
      <div class="masonry">
        <vault-component />
      </div>
    </div>
    <div class="profileKeeps row">
      <h1>Keeps</h1>
      <div class="masonry">
        <keep-component v-for="keep in state.profileKeeps" :key="keep.id" :keep-prop="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import KeepComponent from '../components/KeepComponent.vue'

export default {
  components: { KeepComponent },
  name: 'Profile',
  setup() {
    const route = useRoute()
    const state = reactive({
      account: computed(() => AppState.account),
      viewedProfile: computed(() => AppState.viewedProfile),
      keepCount: computed(() => AppState.profileKeeps.length),
      vaultCount: computed(() => AppState.profileVaults.length),
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults)
    })
    onMounted(() => {
      profilesService.getById(route.params.id)
      profilesService.getKeepsByProfileId(route.params.id)
      profilesService.getVaultsByProfileId(route.params.id)
    })

    return { state }
  }
}
</script>

<style lang="scss" scoped>
@import "../assets/css/global.css";
</style>
