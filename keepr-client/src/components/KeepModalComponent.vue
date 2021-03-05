<template>
  <!-- Modal -->
  <div class="modal fade" :id="'keepModal'+keepProp.id" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-xl">
      <div class="modal-content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-6 my-3">
              <img :src="keepProp.img" class="img-fluid rounded-lg" alt="">
            </div>
            <div class="col-6 d-flex flex-column justify-content-between">
              <div class="row">
                <div class="col-12">
                  <div class="modal-header">
                    <button :id="'closeModal'+keepProp.id" type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                </div>
                <div class="col-12 mb-4 text-center">
                  <span>
                    <i class="fa fa-eye text-primary ml-2 mr-1" aria-hidden="true"></i>
                    {{ keepProp.views }}
                    <span class="text-primary border border-primary pl-1 ml-2 mr-1">
                      K
                    </span>
                    {{ keepProp.keeps }}
                    <i class="fa fa-share-alt text-primary ml-2 mr-1" aria-hidden="true"></i>
                    0
                  </span>
                </div>
              </div>
              <div class="row justify-content-center">
                <div class="col-10 text-center">
                  <div class="modal-body">
                    <h1 class="modal-title" :id="'keepModal'+keepProp.id+'Label'">
                      {{ keepProp.name }}
                    </h1>
                    <p>{{ keepProp.description }} Lorem ipsum dolor sit amet consectetur adipisicing elit. Saepe molestiae error delectus provident assumenda a amet, obcaecati, eaque consequuntur velit voluptatum, debitis laudantium dolor facere aliquam impedit beatae tempora. Ullam.</p>
                  </div>
                  <hr class="solid border border-light mb-5">
                  <p>
                    <span class="text-secondary border border-secondary rounded mx-2 py-1 px-2">Tag1</span>
                    <span class="text-secondary border border-secondary rounded mx-2 py-1 px-2">Tag2</span>
                  </p>
                </div>
              </div>
              <div class="row my-3 justify-content-between">
                <div class="col-3">
                  <div class="dropdown">
                    <button class="btn btn-outline-success dropdown-toggle"
                            type="button"
                            id="addToVaultDropdown"
                            data-toggle="dropdown"
                            aria-haspopup="true"
                            aria-expanded="false"
                    >
                      Add to Vault
                    </button>
                    <div class="dropdown-menu" aria-labelledby="addToVaultDropdown">
                      <button v-for="vault in state.myVaults"
                              :key="vault.id"
                              :vault-prop="vault"
                              class="dropdown-item"
                              type="button"
                              @click="createVaultKeep(state.activeKeep.id, vault.id)"
                      >
                        {{ vault.name }}
                      </button>
                    </div>
                  </div>
                </div>
                <div class="col-4">
                  <button v-if="state.user.isAuthenticated && state.activeVault.creatorId === state.account.id" @click="deleteVaultKeep(keepProp.vaultKeepId)" type="button" class="btn btn-outline-danger">
                    Remove from vault
                  </button>
                </div>
                <div class="col-1 p-1">
                  <i v-if="keepProp.creatorId == state.account.id" @click="deleteKeep(keepProp.id)" class="fa fa-trash fa-2x text-danger" aria-hidden="true"></i>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { vaultKeepsService } from '../services/VaultKeepsService'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService'
import NotificationsService from '../services/NotificationsService'
export default {
  name: 'KeepModalComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const route = useRoute()
    const state = reactive({
      account: computed(() => AppState.account),
      user: computed(() => AppState.user),
      myVaults: computed(() => AppState.myVaults),
      activeKeep: computed(() => AppState.activeKeep),
      activeVault: computed(() => AppState.activeVault)
    })
    async function createVaultKeep(keepId, vaultId) {
      const newVaultKeep = { keepId: keepId, vaultId: vaultId }
      await vaultKeepsService.createVaultKeep(newVaultKeep)
    }
    async function deleteVaultKeep(vaultKeepId) {
      if (await NotificationsService.confirmAction()) {
        document.getElementById('closeModal' + props.keepProp.id).click()
        await vaultKeepsService.deleteVaultKeep(vaultKeepId)
      }
    }
    async function deleteKeep(keepId) {
      if (await NotificationsService.confirmAction()) {
        document.getElementById('closeModal' + props.keepProp.id).click()
        await keepsService.deleteKeep(keepId)
      }
    }
    return {
      route,
      state,
      createVaultKeep,
      deleteVaultKeep,
      deleteKeep
    }
  }

}
</script>

<style lang="scss" scoped>
.fa-trash:hover{
  cursor: pointer;
}
</style>
