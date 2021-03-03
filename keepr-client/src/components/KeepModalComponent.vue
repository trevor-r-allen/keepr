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
            <div class="col-6">
              <div class="row">
                <div class="col-12">
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                </div>
                <div class="col-12 mb-4">
                  <span>
                    <i class="fa fa-eye" aria-hidden="true"></i>
                    {{ keepProp.views }}
                    <span class="text-secondary border border-secondary pl-1">
                      K
                    </span>
                    {{ keepProp.keeps }}
                    <i class="fa fa-share" aria-hidden="true"></i>
                    #sharesPlaceholder
                  </span>
                </div>
              </div>
              <div class="row justify-content-center">
                <div class="col-10">
                  <div class="modal-body">
                    <h1 class="modal-title" :id="'keepModal'+keepProp.id+'Label'">
                      {{ keepProp.name }}
                    </h1>
                    <p>{{ keepProp.description }}</p>
                  </div>
                  <hr class="solid border border-light">
                </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">
                  Close
                </button>
                <button type="button" class="btn btn-success">
                  Save changes
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepModalComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
    })
    return { state }
  }

}
</script>

<style lang="scss" scoped>

</style>
