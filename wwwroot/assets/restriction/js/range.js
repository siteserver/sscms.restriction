var $url = '/restriction/range';
var $urlDelete = $url + '/actions/delete';

var data = utils.init({
  isAllowList: utils.getQueryBoolean('isAllowList'),
  ranges: null
});

var methods = {
  apiGet: function () {
    var $this = this;

    utils.loading(this, true);
    $api.get($url, {
      params: {
        isAllowList: this.isAllowList
      }
    }).then(function (response) {
      var res = response.data;

      $this.ranges = res.ranges;
    }).catch(function (error) {
      utils.error(error);
    }).then(function () {
      utils.loading($this, false);
    });
  },

  apiDelete: function(range) {
    var $this = this;

    utils.loading(this, true);
    $api.post($urlDelete, {
      isAllowList: this.isAllowList,
      range: range
    }).then(function (response) {
      var res = response.data;

      setTimeout(function() {
        $this.apiGet();
        utils.success('IP访问规则删除成功');
        utils.closeLayer();
      }, 30000);
    }).catch(function (error) {
      utils.error(error);
    });
  },

  btnAddClick: function() {
    utils.openLayer({
      title: '添加IP访问规则',
      url: utils.getPageUrl('restriction', 'rangeLayerAdd', {
        isAllowList: this.isAllowList
      })
    })
  },

  btnEditClick: function(range) {
    utils.openLayer({
      title: '编辑IP访问规则',
      url: utils.getPageUrl('restriction', 'rangeLayerAdd', {
        isAllowList: this.isAllowList,
        range: range
      })
    })
  },

  btnDeleteClick: function(range) {
    var $this = this;
    utils.alertDelete({
      title: '删除IP访问规则',
      text: 'IP访问规则：' + range,
      callback: function() {
        $this.apiDelete(range);
      }
    })
  }
};

var $vue = new Vue({
  el: "#main",
  data: data,
  methods: methods,
  created: function () {
    this.apiGet();
  }
});
