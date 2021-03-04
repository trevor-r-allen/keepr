<template>
  <!-- Create Modal -->
  <div class="modal fade"
       id="createKeepModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="createKeepModal"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="createKeepModal">
            Create A New Keep
          </h5>
          <button id="closeModal" type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>

        <div class="modal-body">
          <form @submit.prevent="createKeep">
            <div class="form-group">
              <input type="text"
                     name="Keep name"
                     id="KeepName"
                     class="form-control"
                     placeholder="Keep name"
                     v-model="state.newKeep.name"
              >
              <input type="text"
                     name="Keep description"
                     id="KeepDescription"
                     class="form-control"
                     placeholder="Keep description"
                     v-model="state.newKeep.description"
              >
              <input type="text"
                     name="Keep img"
                     id="KeepImg"
                     class="form-control"
                     placeholder="Keep img"
                     v-model="state.newKeep.img"
              >
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
import { keepsService } from '../services/KeepsService'
export default {
  name: 'CreateKeepModal',
  setup() {
    const state = reactive({
      newKeep: {}
    })
    return {
      state,
      async createKeep() {
        try {
          console.log(state.newKeep)
          await keepsService.createKeep(state.newKeep)
          state.newKeep = {}
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
