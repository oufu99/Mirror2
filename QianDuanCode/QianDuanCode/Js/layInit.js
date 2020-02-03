var form;

layui.use('laypage', function () {
    var laypage = layui.laypage;
    //执行一个laypage实例
    laypage.render({
        elem: 'pageInfo' //注意，这里的 test1 是 ID，不用加 # 号
        , count: 50,
        jump: function (obj, first) {

            //obj包含了当前分页的所有参数，比如：
            console.log(obj.curr); //得到当前页，以便向服务端请求对应页的数据。
            console.log(obj.limit); //得到每页显示的条数

            //首次不执行
            if (!first) {
                //分页代码
                if (obj.curr == 2) {
                    pageModel.listData = ["TT1", "TT2", "TT3", "TT4", "TT5"];
                }
                else if (obj.curr == 3) {
                    pageModel.listData = ["TTT1", "TTT2", "TTT3", "TTT4", "TTT5"];
                }
                else {
                    pageModel.listData = ["T1", "T2", "T3", "T4", "T5"];
                }
            }
        }
    });
});

layui.use('form', function () {
    form = layui.form;

    //监听提交
    form.on('submit(formDemo)', function (data) {
        layer.msg(JSON.stringify(data.field));
        return false;
    });
    $ = layui.jquery;
    //$(document).on('click', '#btnRequest', Monitor);
    //$(document).on('click', '#btnResponse', GetMonitorLog);
    form.render();
});