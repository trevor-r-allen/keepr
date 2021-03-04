<template>
  <div class="home flex-grow-1 container">
    <div class="profileInfo row mt-5">
      <div class="col-3">
        <img :src="state.viewedProfile.picture" alt="">
      </div>
      <div class="col-3">
        <h1>{{ state.viewedProfile.name }}</h1>
        <h6>Vaults: {{ state.vaultCount }}</h6>
        <h6>Keeps: {{ state.keepCount }}</h6>
      </div>
    </div>
    <div class="profileVaults row my-5">
      <div class="col-2">
        <h1>Vaults <i class="fa fa-plus text-primary" data-toggle="modal" data-target="#createVaultModal" aria-hidden="true"></i></h1>
        <create-vault-modal />
      </div>
      <div class="masonry">
        <vault-component v-for="vault in state.profileVaults" :key="vault.id" :vault-prop="vault" />
      </div>
    </div>
    <div class="profileKeeps row my-5">
      <div class="col-2">
        <h1>Keeps <i class="fa fa-plus text-primary" data-toggle="modal" data-target="#createKeepModal" aria-hidden="true"></i></h1>
        <create-keep-modal />
      </div>
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
import CreateVaultModal from '../components/CreateVaultModal.vue'
import CreateKeepModal from '../components/CreateKeepModal.vue'

export default {
  components: { KeepComponent, CreateVaultModal, CreateKeepModal },
  name: 'Profile',
  setup() {
    const route = useRoute()
    const state = reactive({
      account: computed(() => AppState.account),
      viewedProfile: computed(() => AppState.viewedProfile),
      keepCount: computed(() => AppState.profileKeeps.length),
      vaultCount: computed(() => AppState.profileVaults.length),
      profileKeeps: computed(() => AppState.profileKeeps),
      profileVaults: computed(() => AppState.profileVaults),
      myKeeps: computed(() => AppState.myKeeps),
      myVaults: computed(() => AppState.myVaults)
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
