using Autofac;
using Autofac.Integration.Mvc;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HRUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            //把当前程序集中的 Controller 都注册
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            Assembly[] assemblies = new Assembly[] { Assembly.Load("HRDAO"), Assembly.Load("HRBLL") };
            builder.RegisterAssemblyTypes(assemblies)
            .Where(type => !type.IsAbstract)
            .AsImplementedInterfaces().PropertiesAutowired();
            var container = builder.Build();
            //注册系统级别的 DependencyResolver，这样当 MVC 框架创建 Controller 等对象的时候都是管 Autofac 要对象。
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//!!!

            //创建计划者
            IScheduler sched = new StdSchedulerFactory().GetScheduler();
            //给计划者创建一个工作对象
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            //设定工作对象的执行频率
            CalendarIntervalScheduleBuilder builder1 = CalendarIntervalScheduleBuilder.Create();
            builder1.WithInterval(3, IntervalUnit.Second);
            IMutableTrigger triggerBossReport = builder1.Build();
            //3600代表的是1个小时WithIntervalInMonths
            // IMutableTrigger triggerBossReport = CronScheduleBuilder.MonthlyOnDayAndHourAndMinute(22, 10,59).Build();
            //给触发器对象设置键名
            triggerBossReport.Key = new TriggerKey("triggerTest");
            //给计划者安排工作对象和触发器对象
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            //启动计划
            sched.Start();
        }
    }
}
