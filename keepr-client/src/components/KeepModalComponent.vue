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
            <div class="col-6" style="position: relative">
              <div class="row">
                <div class="col-12">
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                </div>
                <div class="col-12 mb-4 ">
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
                <div class="col-10">
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
              <div class="row my-3" style="position: absolute; bottom: 0; left: 0; width: 100%;">
                <div class="col">
                  <div class="dropdown">
                    <button class="btn btn-outline-primary dropdown-toggle"
                            type="button"
                            id="dropdownMenu2"
                            data-toggle="dropdown"
                            aria-haspopup="true"
                            aria-expanded="false"
                    >
                      Dropdown
                    </button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                      <button class="dropdown-item" type="button">
                        Action
                      </button>
                    </div>
                  </div>
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
