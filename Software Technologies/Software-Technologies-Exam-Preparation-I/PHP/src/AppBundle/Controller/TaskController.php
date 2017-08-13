<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\RedirectResponse;
use Symfony\Component\HttpFoundation\Request;

class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
        $tasks = $this->getDoctrine()->getRepository(Task::class)->findAll();

        return $this->render('task\index.html.twig',['tasks'=>$tasks]);
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response|RedirectResponse
     */
    public function create(Request $request)
    {
        $task = new Task();
        $form = $this->createForm(TaskType::class,$task);

        $form->handleRequest($request);

        if($form->isSubmitted())
        {
            $em = $this->getDoctrine()->getManager();
            $em->persist($task);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render('task\create.html.twig',[
            'form'=>$form->createView(),
            'task'=>$task
        ]);
    }

    /**
     * @Route("/delete/{id}", name="delete")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response|RedirectResponse
     */
    public function delete($id, Request $request)
    {
        $task = $this->getDoctrine()->getRepository(Task::class)->find($id);
        $form = $this->createForm(TaskType::class,$task);

        $form->handleRequest($request);
        if($form->isSubmitted())
        {
            $em = $this->getDoctrine()->getManager();
            $em->remove($task);
            $em->flush();

            return $this->redirectToRoute('index');
        }

        return $this->render('task\delete.html.twig',[
            'form'=> $form->createView(),
            'task'=>$task
        ]);
    }
}
