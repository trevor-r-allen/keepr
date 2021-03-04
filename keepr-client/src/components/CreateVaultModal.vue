<template>
  <!-- Create Modal -->
  <div class="modal fade"
       id="createVaultModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="createVaultModal"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="createVaultModal">
            Create A New Vault
          </h5>
          <button id="closeModal" type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>

        <div class="modal-body">
          <form @submit.prevent="createVault">
            <div class="form-group">
              <input type="text"
                     name="Vault name"
                     id="VaultName"
                     class="form-control"
                     placeholder="Vault name"
                     v-model="state.newVault.name"
              >
              <input type="text"
                     name="Vault description"
                     id="VaultDescription"
                     class="form-control"
                     placeholder="Vault description"
                     v-model="state.newVault.description"
              >
              <div class="form-check">
                <input type="checkbox" name="Vault isPrivate" id="VaultIsPrivate" class="form-check-input" v-model="state.newVault.isPrivate">
                <label class="form-check-label" for="VaultIsPrivate">
                  Make Private?
                </label>
              </div>
            </div>
            <button type="submit" class="btn btn-success">
              Create
            </button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'

export default {
  name: 'CreateVaultModal',
  setup() {
    const state = reactive({
      newVault: {}
    })
    return {
      state,
      async createVault() {
        try {
          await vaultsService.createVault(state.newVault)
          state.newVault = {}
          document.getElementById('closeModal').click()
        } catch (error) {

        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
