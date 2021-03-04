<template>
  <router-link :to="{name: 'Vault', params: {id: vaultProp.id}}">
    <div class="vaultComponent card">
      <img class="vaultImg card-img-top img-fluid" src="https://cash-connect.com/img/vault-round.jpg" alt="">
      <h4 class="vaultName card-title text-light" style="position: absolute;">
        {{ vaultProp.name }}
      </h4>
    </div>
  </router-link>
</template>

<script>
import { computed, reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'
export default {
  name: 'VaultComponent',
  props: {
    vaultProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      activeVault: computed(() => AppState.activeVault)
    })
    function getVaultById() {
      vaultsService.getVaultById(props.vaultProp.id)
    }
    return {
      state,
      getVaultById
    }
  }
}
</script>

<style lang="scss" scoped>
.vaultComponent{
position: relative;
border-radius: 10px;
}
.vaultImg{
border-radius: 10px;
}
.vaultName{
  position: absolute;
  bottom: 8px;
  left: 16px;
}
</style>
