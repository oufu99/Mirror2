var form;

layui.use('laypage', function () {
    var laypage = layui.laypage;
    //ִ��һ��laypageʵ��
    laypage.render({
        elem: 'pageInfo' //ע�⣬����� test1 �� ID�����ü� # ��
        , count: 50,
        jump: function (obj, first) {

            //obj�����˵�ǰ��ҳ�����в��������磺
            console.log(obj.curr); //�õ���ǰҳ���Ա������������Ӧҳ�����ݡ�
            console.log(obj.limit); //�õ�ÿҳ��ʾ������

            //�״β�ִ��
            if (!first) {
                //��ҳ����
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

    //�����ύ
    form.on('submit(formDemo)', function (data) {
        layer.msg(JSON.stringify(data.field));
        return false;
    });
    $ = layui.jquery;
    //$(document).on('click', '#btnRequest', Monitor);
    //$(document).on('click', '#btnResponse', GetMonitorLog);
    form.render();
});