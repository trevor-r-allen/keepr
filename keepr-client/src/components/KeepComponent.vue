<template>
  <div class="">
    This is a keep
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({

    })
    return {
      state
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
