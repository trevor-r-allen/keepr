<template>
  <div class="masonry-item">
    <div class="keepComponent card" @click="getKeepById()" data-toggle="modal" :data-target="'#keepModal'+keepProp.id">
      <img class="keepImg card-img-top img-fluid" :src="keepProp.img" alt="">
      <h4 class="keepName card-title text-light" style="position: absolute;">
        {{ keepProp.name }}
      </h4>
      <img @click.stop="toProfilePage()" class="creatorPic img-fluid" :src="keepProp.creator.picture" alt="">
    </div>
    <keep-modal-component :keep-prop="state.activeKeep" />
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import KeepModalComponent from './KeepModalComponent.vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
import router from '../router'
export default {
  components: { KeepModalComponent },
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep)
    })
    function getKeepById() {
      keepsService.getKeepById(props.keepProp.id)
    }
    function toProfilePage() {
      router.push({ name: 'Profile', params: { id: props.keepProp.creatorId } })
    }
    return {
      state,
      getKeepById,
      toProfilePage
    }
  }
}
</script>

<style lang="scss" scoped>
.masonry-item{
  display: inline-block;
  margin: 0 0 1em;
  width: 100%;

}
.keepComponent{
position: relative;
border-radius: 10px;
}
.keepImg{
border-radius: 10px;
}
.keepName{
  position: absolute;
  bottom: 8px;
  left: 16px;
}
.creatorPic{
  box-shadow: 100px 100px 1000px rgba(0, 0, 0, 0);
  position: absolute;
  border-radius: 50%;
  bottom: 8px;
  right: 16px;
  max-height: 50px;
  max-width: 50px;
}
</style>
